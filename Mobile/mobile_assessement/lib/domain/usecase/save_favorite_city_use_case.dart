import 'package:dartz/dartz.dart';


import '../../core/errors/failur.dart';
import '../repositories/repositories.dart';

class SaveFavoriteCityUseCase {
  final WeatherRepository repository;

  SaveFavoriteCityUseCase(this.repository);

  Future<Either<Failure, bool>> call(String city) async {
    try {
      // Perform the logic to save the favorite city
      // ...

      // Assuming the favorite city is successfully saved
      return Right(true);
    } catch (e) {
      // Return a Failure object in case of error
      return Left(ServerFailure('Failed to save favorite city.'));
    }
  }
}
