import 'package:dartz/dartz.dart';
import 'package:mobile_assessement/core/error/failures.dart';
import 'package:mobile_assessement/core/usecases/usecases.dart';
import 'package:mobile_assessement/features/home/domain/entities/city.dart';
import 'package:mobile_assessement/features/home/domain/repositories/city_search_repository.dart';

class SearchCity extends UseCase<City, String> {
  final CitySearchRepository repository;

  SearchCity(this.repository);

  @override
  Future<Either<Failure, City>> call(String cityName) async {
    try {
      final city = await repository.searchCity(cityName);
      return right(city);
    } catch (e) {
      return left(ServerFailure());
    }
  }
}