using Firebase.Database;
using Firebase.Database.Query;
using NailBar_App.Models;
using System.Collections.ObjectModel;

namespace NailBar_App.ViewModels
{
    public class ViewModelCitasPendientesCliente
    {
        private FirebaseClient _firebase;
        private string childString;

        public ObservableCollection<Cita> DataItems { get; } = new ObservableCollection<Cita>();

        public ViewModelCitasPendientesCliente(string child, bool cargar)
        {
            childString = child;
            _firebase = new FirebaseClient(new Controllers.Config().GetUrlCitasPendientesCliente());
            if (cargar)
            {
                ListenToChanges();
            }
        }

        private void ListenToChanges()
        {
            _firebase
                .Child(childString)
                .AsObservable<Cita>()
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
                            
                            //if (citaProx)
                            //{
                            //    if (MainClientePage.citaProxima == null)
                            //    {
                            //        MainClientePage.citaProxima = newItem;
                                    //Debug.WriteLine("PASO Y ASIGNO EL ITEM: "+ MainClientePage.citaProxima.Cliente);

                            //    }
                            //} 
                            
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
                    
                });
        }

        public async Task InsertData(string hIndex, Cita newItem)
        {
            string idItem = newItem.Fecha.Replace("/","") + "_" + hIndex;
            
            await _firebase
                .Child(childString+"/"+idItem)
                .PutAsync(newItem);
        }

        public async Task UpdateData(Cita updatedItem)
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

    }
}
