using Firebase.Database;
using Firebase.Database.Query;
using NailBar_App.Models;
using System.Collections.ObjectModel;

namespace NailBar_App.ViewModels
{
    public class ViewModelUsuarios
    {
        private FirebaseClient _firebase;
        private string childString;

        public ObservableCollection<Usuario> DataItems { get; } = new ObservableCollection<Usuario>();
        public ObservableCollection<string> NombresUsuarios { get; } = new ObservableCollection<string>();

        public ViewModelUsuarios(string child)
        {
            childString = child;
            _firebase = new FirebaseClient(new Controllers.Config().GetUrlUsuarios());
            ListenToChanges();
        }

        public async void ListenToChanges()
        {
            _firebase
                .Child(childString)
                .AsObservable<Usuario>()
                .Subscribe(args =>
                {
                    if (args.EventType == Firebase.Database.Streaming.FirebaseEventType.InsertOrUpdate)
                    {
                        var newItem = args.Object;
                        newItem.Id = args.Key;
                        var existingItem = DataItems.FirstOrDefault(x => x.Id == newItem.Id);

                        if (existingItem != null)
                        {
                            //Item actualizado
                            int index = GetIndexId(newItem.Id);
                            
                            //existingItem.Title = newItem.Title;
                            DataItems.RemoveAt(index);
                            DataItems.Insert(index, newItem);
                        }
                        else
                        {
                            //Nuevo item
                            DataItems.Add(newItem);
                        }
                    }
                    else if (args.EventType == Firebase.Database.Streaming.FirebaseEventType.Delete)
                    {
                        // Un item se ha eliminado de datos
                        var itemToRemove = DataItems.FirstOrDefault(x => x.Id == args.Key);
                        if (itemToRemove != null)
                        {
                            DataItems.Remove(itemToRemove);
                        }
                    }

                    llenarNombreUsuarios();//Llena la lista con el nombre de usuarios
                });
        }

        public async Task InsertData(Usuario newItem)
        {
            await _firebase
                .Child(childString)
                .PostAsync(newItem);
            //.PostAsync(newItem, false);
        }

        public async Task UpdateData(Usuario updatedItem)
        {
            await _firebase
                .Child(childString)
                .Child(updatedItem.Id)
                .PutAsync(updatedItem);
        }

        public async Task DeleteData(string itemId)
        {
            await _firebase
                .Child(childString)
                .Child(itemId)
                .DeleteAsync();
        }

        public int GetIndexId(string itemId)
        {
            for (int i = 0; i < DataItems.Count; i++)
            {
                if (DataItems[i].Id == itemId)
                {
                    return i; // Devuelve el índice si se encuentra el elemento
                }
            }
            return -1; // Devuelve -1 si no se encuentra el elemento con ese Id
        }

        public async void llenarNombreUsuarios()
        {
            NombresUsuarios.Clear();
            foreach (var item in DataItems)
            {
                NombresUsuarios.Add(item.Nombre);
            }
            
        }
    }
}
