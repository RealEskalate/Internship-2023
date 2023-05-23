
import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile_assessement/domain/Entity/weather_entity.dart';

import '../../core/error_handle/failure.dart';
import '../../core/usecase.dart';
import '../repositories/weather_repo.dart';

class GetWeatherData<WeatherEntity, String> {
  final WeatherRepository repo;
  GetWeatherData(this.repo);

  @override
  Future<Either<Failure, WeatherEntity>> call(String city) async {
    
    return await repo.fetchWeatherData(city);
  }
}