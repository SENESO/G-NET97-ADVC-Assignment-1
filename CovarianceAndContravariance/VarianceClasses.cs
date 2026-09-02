namespace Assignment01.CovarianceAndContravariance
{
    // Model hierarchy for Variance demonstration
    public class VAnimal
    {
        public string Name { get; set; }
        public VAnimal(string name) => Name = name;
        public override string ToString() => $"Animal: {Name}";
    }

    public class VDog : VAnimal
    {
        public VDog(string name) : base(name) { }
        public override string ToString() => $"Dog: {Name}";
    }

    public class VCat : VAnimal
    {
        public VCat(string name) : base(name) { }
        public override string ToString() => $"Cat: {Name}";
    }

    // Q15: Covariance - 'out' keyword indicates T is used only as an OUTPUT (return type).
    // Allows assigning IProducer<VDog> to IProducer<VAnimal> (Derived to Base).
    public interface IProducer<out T>
    {
        T Produce();
    }

    public class DogProducer : IProducer<VDog>
    {
        private readonly string _name;
        public DogProducer(string name) => _name = name;

        public VDog Produce() => new VDog(_name);
    }

    // Q16: Contravariance - 'in' keyword indicates T is used only as an INPUT (method parameter).
    // Allows assigning IConsumer<VAnimal> to IConsumer<VDog> (Base to Derived).
    public interface IConsumer<in T>
    {
        void Consume(T item);
    }

    public class AnimalConsumer : IConsumer<VAnimal>
    {
        public void Consume(VAnimal item)
        {
            Console.WriteLine($"  [AnimalConsumer] Consumed: {item.Name} ({item.GetType().Name})");
        }
    }
}
