using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using zadatak1;

namespace Zadatak4
{
    class ExpressionSingleton
    {
        private static ExpressionSingleton instance = null;
        private static readonly object obj = new object();
        ReaderWriterLockSlim rw = new ReaderWriterLockSlim();

        ExpressionSingleton()
        {           

        }

        public static ExpressionSingleton Instance
        {
            get
            {
                lock (obj)
                {
                    if (instance == null)
                    {
                        instance = new ExpressionSingleton();
                    }
                }
                
                return instance;
            }
        }
        

        public List<Guid> ListId(List<ExpressionContainer> list)
        {

            List<Guid> lst = new List<Guid>();
            rw.EnterReadLock();

            try
            {
                foreach (ExpressionContainer exp in list)
                {
                    lst.Add(exp.Id);
                }
                Thread.Sleep(1000);
                return lst;
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                rw.ExitReadLock();
            }            
        }

        public void ChangeExpression(ExpressionContainer exp, MyExpression newExpression)
        {
            rw.EnterWriteLock();

            try
            {
                exp.Expression = newExpression;
                Thread.Sleep(5000);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                rw.ExitWriteLock();
            }
        }

        public void ChangeName(ExpressionContainer exp, string newName)
        {
            rw.EnterWriteLock();

            try
            {
                exp.Name = newName;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                rw.ExitWriteLock();
            }

            Thread.Sleep(5000);
        }
    }
}
