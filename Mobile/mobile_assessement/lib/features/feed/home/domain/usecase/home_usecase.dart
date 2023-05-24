import 'package:mobile_assessement/core/error/failures.dart';
import 'package:mobile_assessement/core/usecases/usecase.dart';
import 'package:mobile_assessement/features/feed/home/domain/repository/home_repository.dart';
import 'package:dartz/dartz.dart';
import '../entity/home.dart';

class Search extends UseCase<Home, Params> {
  final HomeRepository homeRepository;

  Search({required this.homeRepository});
  @override
  Future<Either<Failure, Home>> call(Params params) async {
    return await homeRepository.search(params.city);
  }
}

class Params {
  final String city;

  Params({required this.city});
}

// class GetFav {
//   final HomeRepository homeRepository;
//   GetFav(this.homeRepository);
//   @override
//   Future<Either<Failure, List<Home>>> call() async {
//     return await homeRepository.getFav();
//   }

// 
// }
