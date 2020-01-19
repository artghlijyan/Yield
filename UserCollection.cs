using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Yield
{
    class UserCollection
    {
        public static IEnumerable Power()
        {
            yield return "Hello World";
        }
    }

    // under yield operator

    class UnderYield
    {
        public static IEnumerable Power()
        {
            return new ClassPower(-2);
        }

        private sealed class ClassPower : IEnumerable<object>, IEnumerator<object>, IEnumerator, IDisposable
        {
            private int state;
            private object current;
            private int initialThreadId;

            public ClassPower(int state)
            {
                this.state = state;
                this.initialThreadId = Thread.CurrentThread.ManagedThreadId;
            }

            bool IEnumerator.MoveNext()
            {
                switch (this.state)
                {
                    case 0:
                        this.state = -1;
                        this.current = "Hello World";
                        this.state = 1;
                        return true;

                    case 1:
                        this.state = -1;
                        break;
                }
                return false;
            }

            IEnumerator<object> IEnumerable<object>.GetEnumerator()
            {
                if ((Thread.CurrentThread.ManagedThreadId == this.initialThreadId) && this.state == -2)
                {
                    this.state = 0;
                    return this;
                }
                return new ClassPower(0);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return (this as IEnumerable<object>).GetEnumerator();
            }

            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }

            object IEnumerator<object>.Current
            {
                get
                {
                    return this.current;
                }
            }

            void IDisposable.Dispose()
            {

            }

            object IEnumerator.Current
            {
                get
                {
                    return this.current;
                }
            }

        }
    }
}
