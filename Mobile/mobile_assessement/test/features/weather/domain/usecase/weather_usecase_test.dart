import 'package:flutter_test/flutter_test.dart';
import 'package:mobile_assessement/core/error/failures.dart';
import 'package:mobile_assessement/features/weather/domain/repository/weather_repository.dart';
import 'package:mobile_assessement/features/weather/domain/usercase/weather_usecase.dart';
import 'package:mockito/annotations.dart';
// import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'package:dartz/dartz.dart';
import 'weather_usecase_test.mocks.dart';

// Create a mock repository class
// class MockWeatherRepository extends Mock implements WeatherRepository {}
@GenerateMocks([WeatherRepository])
void main() {
  late GetWeatherForCityUseCase useCase;
  late MockWeatherRepository mockRepository;

  setUp(() {
    mockRepository = MockWeatherRepository();
    useCase = GetWeatherForCityUseCase(mockRepository);
  });

  const city = 'London';

  test('should return a failure when weather data retrieval fails', () async {
    // Stub the repository method to return a Left value with a failure object
    when(mockRepository.getWeatherForCity(city))
        .thenAnswer((_) async => Left(ServerFailure()));

    // Call the use case
    final result = await useCase(city);

    // Verify that the repository method was called once with the correct city parameter
    verify(mockRepository.getWeatherForCity(city));

    // Verify that the result is a Left value with a failure object
    expect(result, equals(Left(ServerFailure())));

    // Verify that no other repository methods were called
    verifyNoMoreInteractions(mockRepository);
  });
}
