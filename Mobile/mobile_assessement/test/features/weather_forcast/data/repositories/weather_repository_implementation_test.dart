import 'package:dartz/dartz.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:mobile_assessement/features/weather_forcast/data/repositories/weather_reposiotry_implementation.dart';
import 'package:mockito/annotations.dart';
import 'package:mockito/mockito.dart';
import 'package:mobile_assessement/core/errors/exceptions.dart';
import 'package:mobile_assessement/core/errors/failures.dart';
import 'package:mobile_assessement/features/weather_forcast/data/datasources/weather_remote_data_source.dart';
import 'package:mobile_assessement/features/weather_forcast/data/models/weather_forcast_model.dart';
import 'package:mobile_assessement/features/weather_forcast/data/models/weather_model.dart';

import 'weather_repository_implementation_test.mocks.dart';


@GenerateMocks([WeatherRemoteDataSource])
void main() {
 late WeatherRepositoryImplementation repository;
 late MockWeatherRemoteDataSource mockRemoteDataSource;

 setUp(() {
 mockRemoteDataSource = MockWeatherRemoteDataSource();
 repository = WeatherRepositoryImplementation(
 remoteDataSource: mockRemoteDataSource);
 });

 group('getCurrentWeather', () {
 final tCity = 'London';
 final tWeatherModel = WeatherModel(
 condition: 'Clouds',
 conditionIcon: '04d',
 temperature: 15.0,
 highTemperature: 20.0,
 lowTemperature: 10.0,
 windSpeed: 5.0,
 humidity: 80,
 date: DateTime.now(),
 );

 test(
 'should return remote data when the call to remote data source is successful',
 () async {
 // arrange
 when(mockRemoteDataSource.getCurrentWeather(any))
 .thenAnswer((_) async => tWeatherModel);
 // act
 final result = await repository.getCurrentWeather(tCity);
 // assert
 verify(mockRemoteDataSource.getCurrentWeather(tCity));
 expect(result, equals(Right(tWeatherModel)));
 });

 test(
 'should return server failure when the call to remote data source is unsuccessful',
 () async {
 // arrange
 when(mockRemoteDataSource.getCurrentWeather(any))
 .thenThrow(ServerException("Server Failure"));
 // act
 final result = await repository.getCurrentWeather(tCity);
 // assert
 verify(mockRemoteDataSource.getCurrentWeather(tCity));
 expect(result, equals(Left(ServerFailure("Server Failure"))));
 });
 });

 group('getWeatherForecast', () {
 final tCity = 'London';
 final tWeatherForecastModel = WeatherForecastModel(forecast: [
 WeatherModel(
 condition: 'Clouds',
 conditionIcon: '04d',
 temperature: 15.0,
 highTemperature: 20.0,
 lowTemperature: 10.0,
 windSpeed: 5.0,
 humidity: 80,
 date: DateTime.now(),
 )
 ]);

 test(
 'should return remote data when the call to remote data source is successful',
 () async {
 // arrange
 when(mockRemoteDataSource.getWeatherForecast(any))
 .thenAnswer((_) async => tWeatherForecastModel);
 // act
 final result = await repository.getWeatherForecast(tCity);
 // assert
 verify(mockRemoteDataSource.getWeatherForecast(tCity));
 expect(result, equals(Right(tWeatherForecastModel)));
 });

 test(
 'should return server failure when the call to remote data source is unsuccessful',
 () async {
 // arrange
 when(mockRemoteDataSource.getWeatherForecast(any))
 .thenThrow(ServerException("Server Failure"));
 // act
 final result = await repository.getWeatherForecast(tCity);
 // assert
 verify(mockRemoteDataSource.getWeatherForecast(tCity));
 expect(result, equals(Left(ServerFailure("Server Failure"))));
 });
 });
}
