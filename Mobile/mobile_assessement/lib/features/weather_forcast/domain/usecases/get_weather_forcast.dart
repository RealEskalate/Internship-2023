import 'package:dartz/dartz.dart';
import '../../../../core/errors/failures.dart';
import '../../../../core/usecases/usecase.dart';
import '../entities/weather_forcast.dart';
import '../repositories/weather_repository.dart';

class GetWeatherForecast extends UseCase<WeatherForecast, String> {
  final WeatherRepository repository;

  GetWeatherForecast({required this.repository});

  @override
  Future<Either<Failure, WeatherForecast>> call(String params) async {
    return await repository.getWeatherForecast(params);
  }
}
