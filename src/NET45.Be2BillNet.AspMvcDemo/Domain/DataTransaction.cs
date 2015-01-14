
namespace Be2BillNet.AspMvcDemo.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DataTransaction<TData> : IDisposable
    {
        private bool isDisposed;
        private Action<TData> disposeAction;
        private Action<TData> saveAction;

        public DataTransaction(TData data, Action<TData> saveAction, Action<TData> disposeAction)
        {
            this.Data = data;
            this.disposeAction = disposeAction;
            this.saveAction = saveAction;
        }

        public TData Data { get; set; }

        public void Save()
        {
            var action = this.saveAction;
            this.saveAction = null;
            if (action != null)
            {
                action(this.Data);
            }
        }
        
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {
                    this.disposeAction(this.Data);
                    this.disposeAction = null;
                }

                this.isDisposed = true;
            }
        }
    }
}
