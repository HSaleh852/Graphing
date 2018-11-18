namespace Graphing.Type
{
    public enum GraphPermissions
    {
        None = 0,
        AllowLoops = 1 << 0,
        AllowMultipleEdges = 1 << 1
    }
    public enum GraphBehaviour
    {
        IgnoreUnpermittedBehaviour = 0,
        ThrowUnpermittedBehaviour = 1
    }

    public abstract class GraphObject
    {
        protected static GraphPermissions defaultPermissions;
        protected static GraphBehaviour defaultBehaviour;

        static GraphObject()
        {
            defaultPermissions = GraphPermissions.None;
            defaultBehaviour = GraphBehaviour.ThrowUnpermittedBehaviour;
        }

        public static void SetDefaultBehaviour(GraphPermissions permissions, GraphBehaviour behaviour)
        {
            defaultPermissions = permissions;
            defaultBehaviour = behaviour;
        }

        protected readonly GraphPermissions permissions;
        protected readonly GraphBehaviour behaviour;

        protected GraphObject(GraphPermissions permissions, GraphBehaviour behaviour)
        {
            this.permissions = permissions;
            this.behaviour = behaviour;
        }
    }
}
