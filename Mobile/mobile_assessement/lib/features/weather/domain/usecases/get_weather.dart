import 'package:dartz/dartz.dart';
import '../../../../core/errors/failures.dart';
import '../entities/weather.dart';
import '../repositories/weather_repository.dart';

class GetWeather {
  final WeatherRepository repository;
  GetWeather({required this.repository});

  Future<Either<Failure, Weather>> call(String cityName) async {
    print("came here");
    return await repository.getWeather(cityName);
  }
}
