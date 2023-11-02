using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Response.Const
{
    public class SalesGoResponse : IDisposable
    {
   
            public string Message { get; set; }
            public bool IsSuccess { get; set; }
            public object Data { get; set; }

            private bool disposed = false;
            public SalesGoResponse(string message, bool success, object data)
            {
                Message = message;
                IsSuccess = success;
                Data = data;
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!disposed)
                {
                    if (disposing)
                    {
                        // Dispose of managed resources here
                    }

                    // Dispose of unmanaged resources here

                    disposed = true;
                }
            }

            // Destructor for finalization
            ~SalesGoResponse()
            {
                Dispose(false);
            }
        }
    public static class CustomRequest
        {
            public static SalesGoResponse CreateResponse(string message, bool isSuccess, object Data)
            {
                var _SeatBoxResponse = new SalesGoResponse(message, isSuccess, Data);
                return _SeatBoxResponse;
            }
        }
   
}
