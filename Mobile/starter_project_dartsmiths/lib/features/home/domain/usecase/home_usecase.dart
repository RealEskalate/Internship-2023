import 'package:dartsmiths/core/error/failures.dart';
import 'package:dartsmiths/core/usecases/usecase.dart';
import 'package:dartsmiths/features/home/domain/repository/home_repository.dart';
import 'package:dartz/dartz.dart';

import '../entity/home.dart';

class GetBytag extends UseCase<Home, Params> {
  final HomeRepository homeRepository;
  GetBytag({required this.homeRepository});

  @override
  Future<Either<Failure, Home>> call(Params params) async {
<<<<<<< HEAD
<<<<<<< HEAD
    return await homeRepository.filterByTag(params.tag!);
=======
    return await homeRepository.filterByTag(params.tag);
>>>>>>> 14264dae ([Mobile] home page domain layer)
=======
    return await homeRepository.filterByTag(params.tag);
>>>>>>> 3c40e5a6 ([Mobile] home page domain layer)
  }
}

class Search extends UseCase<Home, Params> {
  final HomeRepository homeRepository;

  Search({required this.homeRepository});
  @override
  Future<Either<Failure, Home>> call(Params params) async {
<<<<<<< HEAD
<<<<<<< HEAD
    return await homeRepository.search(params.term!, params.tag!);
=======
    return await homeRepository.search(params.term, params.tag);
>>>>>>> 14264dae ([Mobile] home page domain layer)
=======
    return await homeRepository.search(params.term, params.tag);
>>>>>>> 3c40e5a6 ([Mobile] home page domain layer)
  }
}

class Params {
<<<<<<< HEAD
<<<<<<< HEAD
  String? term;
  String? tag;
  Params({this.tag, this.term});
=======
  String term;
  String tag;
  Params({required this.tag, required this.term});
>>>>>>> 14264dae ([Mobile] home page domain layer)
=======
  String term;
  String tag;
  Params({required this.tag, required this.term});
>>>>>>> 3c40e5a6 ([Mobile] home page domain layer)
}
