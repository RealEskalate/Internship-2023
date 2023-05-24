import 'package:dartz/dartz.dart';
import 'package:mobile_assessement/features/weather/data/models/weather_detail_model.dart';
import 'package:mobile_assessement/features/weather/domain/usecases/get_weather_detail.dart';
import '../../../../core/error/exception.dart';
import '../../../../core/error/failures.dart';
import '../../../../core/network/network_info.dart';
import '../../domain/entities/weather_detail_domain.dart';
import '../../domain/repositories/weather_repository.dart';
import '../datasources/weather_detail_remote_data_source.dart';


class WeatherRepositoryImpl implements WeatherRepository {

  final WeatherRemoteDataSource remoteDataSource;
  final NetworkInfo networkInfo;

  WeatherRepositoryImpl({
    required this.remoteDataSource,
    required this.networkInfo,
  });
  
  @override
  Future<Either<Failure, TemperatureData>> getWeather(String id) async{
    try {
      TemperatureDataModel temperatureDataModel =   await remoteDataSource.GetWeather(id);
      
      TemperatureData temperatureData = TemperatureData(iconUrl: temperatureDataModel.iconUrl, city: temperatureDataModel.city, temperatureDataDetail: temperatureDataModel.temperatureDataDetailModel.map((e) => TemperatureDataDetail(iconUrl: e.iconUrl, weatherDescription: e.weatherDescription, date: e.date, minTemp: e.minTemp, maxTemp: e.maxTemp, humidity: e.humidity, avgTemp: e.avgTemp)).toList() );
      return Right(temperatureData);
    } on ServerException {
      return Left(ServerFailure());
    }

  }

  
}
