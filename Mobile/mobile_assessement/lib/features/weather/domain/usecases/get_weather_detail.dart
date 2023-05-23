import 'package:dartz/dartz.dart';
import 'package:flutter/material.dart';
import 'package:mobile_assessement/features/weather/domain/entities/weather_detail_domain.dart';
import 'package:mobile_assessement/features/weather/domain/repositories/weather_repository.dart';

import '../../../../core/error/failures.dart';
import '../../../../core/usecases/usecase.dart';


class GetWeather implements UseCase<TemperatureData, String> {
  final WeatherRepository weatherRepository;

  GetWeather(this.weatherRepository);

  Future<Either<Failure, TemperatureData>> call(id) async {
    return await weatherRepository.getWeather(id);
  }
}
