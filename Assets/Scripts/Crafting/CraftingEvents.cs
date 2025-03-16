namespace AF_Interview.Crafting
{
    public enum CraftingResult
    {
        Success,
        Failure
    }
    
    public abstract class CraftingEventBase
    {
        public Recipe Recipe;
    }

    public class CraftingStartedEvent : CraftingEventBase
    {
        public CraftingMachine CraftingMachine;
    }

    public class CraftingProgressUpdatedEvent : CraftingEventBase
    {
        public CraftingMachine CraftingMachine;
        public float CraftingProgressTime;
    }
    
    public class CraftingFinishedEvent : CraftingEventBase
    {
        public CraftingMachine CraftingMachine;
        public CraftingResult CraftingResult;
    }
    public class UnlockedCraftingMachineEvent
    {
        public CraftingMachine CraftingMachine;
    }
}
