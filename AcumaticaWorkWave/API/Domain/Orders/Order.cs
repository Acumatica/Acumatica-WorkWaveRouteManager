using Newtonsoft.Json;
using System;

namespace AcumaticaWorkWave.API.Domain.Orders
{
    public class Order
    {
        private OrderStep delivery;
        private Eligibility eligibility;
        private Loads loads;
        private OrderStep pickup;

        [JsonProperty("id")]
        public Guid? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("eligibility")]
        public Eligibility Eligibility
        {
            get => eligibility;
            set => eligibility = value;
        }

        [JsonProperty("forceVehicleId")]
        public Guid? ForceVehicleId { get; set; }

        [JsonProperty("priority")]
        public int Priority { get; set; }

        [JsonProperty("loads")]
        public Loads Loads
        {
            get => loads;
            set => loads = value;
        }

        [JsonProperty("delivery")]
        public OrderStep Delivery
        {
            get => delivery;
            set => delivery = value;
        }

        [JsonProperty("pickup")]
        public OrderStep Pickup
        {
            get => pickup;
            set => pickup = value;
        }

        [JsonProperty("isService")]
        public bool IsService { get; set; }

        public Order WithEligibility(Func<Eligibility, Eligibility> func = null)
        {
            eligibility = new Eligibility();
            func?.Invoke(eligibility);

            return this;
        }

        public Order WithLoads(Func<Loads, Loads> func = null)
        {
            loads = new Loads();
            func?.Invoke(loads);

            return this;
        }

        public Order WithDelivery(Func<OrderStep, OrderStep> func = null)
        {
            delivery = new OrderStep();
            func?.Invoke(delivery);

            return this;
        }

        public Order WithPickup(Func<OrderStep, OrderStep> func = null)
        {
            pickup = new OrderStep();
            func?.Invoke(pickup);

            return this;
        }
    }
}