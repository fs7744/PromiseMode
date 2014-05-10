using System.Threading;

namespace ActorModel
{
    internal sealed class Dispatcher
    {
        public static readonly Dispatcher Instance = new Dispatcher();

        public void ReadyToExecute(Actor actor)
        {
            if (actor.Finished) return;

            int status = Interlocked.CompareExchange(ref actor.m_Status, Actor.Excuting, Actor.Waiting);

            if (status == Actor.Waiting)
            {
                ThreadPool.QueueUserWorkItem(this.Execute, actor);
            }
        }

        private void Execute(object o)
        {
            Actor actor = o as Actor;
            if (actor == null) return;

            actor.Execute();

            if (actor.Finished)
            {
                Thread.VolatileWrite(ref actor.m_Status, Actor.Ended);
            }
            else
            {
                Thread.VolatileWrite(ref actor.m_Status, Actor.Waiting);
                if (actor.MessageCount > 0)
                {
                    ReadyToExecute(actor);
                }
            }
        }
    }
}
