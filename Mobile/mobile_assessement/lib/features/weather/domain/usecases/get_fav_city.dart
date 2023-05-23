import 'package:dartz/dartz.dart';
import 'package:flutter/material.dart';
import 'package:mobile_assessement/features/weather/domain/entities/weather.dart';

import '../../../../core/error/failures.dart';
import '../../../../core/usecases/usecase.dart';
import '../repositories/weather_repo.dart';

class GetFavCity implements UseCase<Weather, String> {
  final WeatherRepository repository;

  GetFavCity(this.repository);

  Future<Either<Failure, Weather>> call(favKey) async {
    return await repository.getWeather(favKey);
  }
}
