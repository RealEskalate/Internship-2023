// import 'package:dartz/dartz.dart';
// import 'package:mobile_assessement/core/error/exceptions.dart';
// import 'package:mobile_assessement/core/error/failures.dart';
// import 'package:mobile_assessement/core/network/network_info.dart';
// import 'package:mobile_assessement/features/weather_details/data/datasources/weather_remote_data_source.dart';
// import 'package:mobile_assessement/features/weather_details/data/models/weather_model.dart';
// import 'package:mobile_assessement/features/weather_details/domain/entities/weather.dart';
// import 'package:mobile_assessement/features/weather_details/domain/repositories/weather_repository.dart';

// class WeatherRepositoryImpl implements WeatherRepository {
//   final WeatherRemoteDataSource remoteDataSource;
//   final NetworkInfo networkInfo;

//   WeatherRepositoryImpl({
//     required this.remoteDataSource,
//     required this.networkInfo,
//   });

//   @override
//   Future<Either<Failure, Weather>> getWeeklyWeather(String weatherName) async {
//     if (await networkInfo.isConnected) {
//       try {
//         final weatherModels =
//             await remoteDataSource.getWeeklyWeather(weatherName);
//         return Right(weatherModels
//             .map((weather) => WeatherModel(
//                   date: weather.date,
//                   condition: weather.condition,
//                   temperature: weather.temperature,
//                   humidity: weather.humidity,
//                   windSpeed: weather.windSpeed,
//                 ))
//             .toList());
//       } on ServerException {
//         return Left(ServerFailure());
//       }
//     } else {
//       return Left(NetworkFailure());
//     }
//   }
// }
