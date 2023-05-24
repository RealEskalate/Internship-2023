
import 'package:dartz/dartz.dart';
import 'package:mobile_assessement/features/weatherify/data/data_source/weater_remote_data_source.dart';
import '../../../../core/errors/exceptions.dart';
import '../../../../core/errors/failures.dart';
import '../../domain/entity/weather_entity.dart';
import '../../domain/repository/weather_repository.dart';

class WeatherRepositoryImpl implements WeatherRepository {
  final WeatherRemoteDataSource weatherApiClient;

  WeatherRepositoryImpl({required this.weatherApiClient});

  @override
  Future<Either<Failure, Weather>> getWeatherForCity(String city) async {
    try {
      final weather = await weatherApiClient.getWeather(city);
  
      return Right(weather);
    } on ServerException {
      return Left(ServerFailure());
    }
  }
  
  @override
  Future<void> saveWeather(weather) {
    // TODO: implement saveWeather
    throw UnimplementedError();
  }

  
}