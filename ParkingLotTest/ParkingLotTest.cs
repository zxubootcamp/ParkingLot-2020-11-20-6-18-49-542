using System.Linq;

namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class FakeParkingLot : ParkingLot
    {
        public FakeParkingLot(uint id) : base(id)
        {
        }

        public new bool HasCar(ICar car)
        {
            return this.ParkingLotPlaces.Where(idCarPair => idCarPair.Value.Equals(car)).ToList().Count == 1;
        }
    }

    public class ParkingLotTest
    {
        [Fact]
        public void Should_generate_ParkingLot()
        {
            // given
            var parkingLot = new ParkingLot(0);
            // then
            Assert.NotNull(parkingLot);
        }

        [Fact]
        public void Should_add_car_into_parkingLotPlaces_when_AddCar()
        {
            // given
            var fakeParkingLot = new FakeParkingLot(0);
            var car = new Car();
            // when
            fakeParkingLot.AddCar(car);
            var isCarAdded = fakeParkingLot.HasCar(car);
            // then
            Assert.True(isCarAdded);
        }

        [Fact]
        public void Should_get_car_from_parkingLotPlaces_when_GetCar_by_carId()
        {
            // given
            var fakeParkingLot = new FakeParkingLot(0);
            var expectedCar = new Car();
            // when
            fakeParkingLot.AddCar(expectedCar);
            var actualCar = fakeParkingLot.GetCar(0);
            // then
            Assert.Equal(expectedCar, actualCar);
        }

        [Fact]
        public void Should_delete_pair_of_carId_car_car_from_parkingLotPlaces_when_GetCar_by_carId()
        {
            // given
            var fakeParkingLot = new FakeParkingLot(0);
            var expectedCar = new Car();
            // when
            fakeParkingLot.AddCar(expectedCar);
            var actualCar = fakeParkingLot.GetCar(0);
            var isCarStillExists = fakeParkingLot.HasCarId(0);
            // then
            Assert.False(isCarStillExists);
        }

        [Fact]
        public void Should_return_true_when_use_HasCar_to_check_if_car_is_already_parked_in_this_ParkingLot()
        {
            // given
            var parkingLot = new ParkingLot(0);
            var car = new Car();
            // when
            parkingLot.AddCar(car);
            var hasCar = parkingLot.HasCar(car);
            // then
            Assert.True(hasCar);
        }

        [Fact]
        public void Should_return_false_when_use_HasCar_to_check_if_a_new_car_is_already_parked_in_this_ParkingLot()
        {
            // given
            var parkingLot = new ParkingLot(0);
            var car = new Car();
            // when
            parkingLot.AddCar(car);
            var hasCar = parkingLot.HasCar(new Car());
            // then
            Assert.False(hasCar);
        }

        [Fact]
        public void Should_return_true_when_use_HasCarId_to_check_if_a_car_with_carId_already_parked_into_this_parkingLot()
        {
            // given
            var parkingLot = new ParkingLot(0);
            var car = new Car();
            // when
            parkingLot.AddCar(car);
            var hasCarId = parkingLot.HasCarId(0);
            // then
            Assert.True(hasCarId);
        }

        [Fact]
        public void Should_return_false_when_use_HasCarId_to_check_if_no_car_with_carId_parked_into_this_parkingLot()
        {
            // given
            var parkingLot = new ParkingLot(0);
            var car = new Car();
            // when
            parkingLot.AddCar(car);
            var hasCarId = parkingLot.HasCarId(1);
            // then
            Assert.False(hasCarId);
        }

        [Fact]
        public void Should_return_1_when_check_carId_after_added_a_car()
        {
            // given
            var fakeParkingLot = new FakeParkingLot(0);
            var car = new Car();
            // when
            fakeParkingLot.AddCar(car);
            var carId = fakeParkingLot.CarId;
            // then
            Assert.Equal(1U, carId);
        }

        [Fact]
        public void Should_return_true_when_use_IsCarIdGenerated_to_check_if_a_provided_carId_was_provided()
        {
            // given
            var parkingLot = new ParkingLot(0);
            var car = new Car();
            // when
            parkingLot.AddCar(car);
            var isCarIdGenerated = parkingLot.IsCarIdProvided(0);
            // then
            Assert.True(isCarIdGenerated);
        }

        [Fact]
        public void Should_return_false_when_use_IsCarIdGenerated_to_check_if_a_carId_was_not_provided()
        {
            // given
            var parkingLot = new ParkingLot(0);
            var car = new Car();
            // when
            parkingLot.AddCar(car);
            var isCarIdGenerated = parkingLot.IsCarIdProvided(1);
            // then
            Assert.False(isCarIdGenerated);
        }

        [Fact]
        public void Should_return_false_when_has_no_position_in_parking_lot()
        {
            // given
            var parkingLot = new ParkingLot(0, 1);
            var car = new Car();
            parkingLot.AddCar(car);
            // when
            bool hasPosition = parkingLot.HasPosition();
            // then
            Assert.False(hasPosition);
        }

        [Fact]
        public void Should_return_true_when_has_position_in_parking_lot()
        {
            // given
            var parkingLot = new ParkingLot(0, 2);
            var car = new Car();
            parkingLot.AddCar(car);
            // when
            bool hasPosition = parkingLot.HasPosition();
            // then
            Assert.True(hasPosition);
        }
    }
}
