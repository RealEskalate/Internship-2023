import 'package:dartz/dartz.dart';
import '../../../../core/errors/failures.dart';
import '../../../../core/usecases/usecase.dart';
import '../entities/weather.dart';
import '../repositories/weather_repository.dart';

class GetCurrentWeather extends UseCase<Weather, String> {
  final WeatherRepository repository;

  GetCurrentWeather({required this.repository});

  @override
  Future<Either<Failure, Weather>> call(String params) async {
    return await repository.getCurrentWeather(params);
  }
}
