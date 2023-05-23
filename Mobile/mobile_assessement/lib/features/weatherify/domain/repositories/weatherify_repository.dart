// ignore: depend_on_referenced_packages
import 'package:dartz/dartz.dart';
import 'package:mobile_assessement/features/weatherify/domain/entities/weather.dart';

import '../../../../core/errors/failure.dart';

abstract class WeatherifyRepository {

  Future<Either<Failure, Weather>> searchCity(String cityName);

}
