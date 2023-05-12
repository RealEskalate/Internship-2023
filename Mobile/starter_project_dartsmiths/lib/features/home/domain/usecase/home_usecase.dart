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
<<<<<<< HEAD
    return await homeRepository.filterByTag(params.tag!);
=======
    return await homeRepository.filterByTag(params.tag);
>>>>>>> 14264dae ([Mobile] home page domain layer)
=======
    return await homeRepository.filterByTag(params.tag);
>>>>>>> 3c40e5a6 ([Mobile] home page domain layer)
=======
    return await homeRepository.filterByTag(params.tag!);
=======
    return await homeRepository.filterByTag(params.tag);
>>>>>>> 45ce3b90f7597f464f062d467352d6466d59949b
>>>>>>> f340f282cc677cc910fd6b6f528cf33da32dd0c1
  }
}

class Search extends UseCase<Home, Params> {
  final HomeRepository homeRepository;

  Search({required this.homeRepository});
  @override
  Future<Either<Failure, Home>> call(Params params) async {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    return await homeRepository.search(params.term!, params.tag!);
=======
    return await homeRepository.search(params.term, params.tag);
>>>>>>> 14264dae ([Mobile] home page domain layer)
=======
    return await homeRepository.search(params.term, params.tag);
>>>>>>> 3c40e5a6 ([Mobile] home page domain layer)
=======
    return await homeRepository.search(params.term!, params.tag!);
=======
    return await homeRepository.search(params.term, params.tag);
>>>>>>> 45ce3b90f7597f464f062d467352d6466d59949b
>>>>>>> f340f282cc677cc910fd6b6f528cf33da32dd0c1
  }
}

class Params {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> f340f282cc677cc910fd6b6f528cf33da32dd0c1
  String? term;
  String? tag;
  Params({this.tag, this.term});
=======
  String term;
  String tag;
  Params({required this.tag, required this.term});
<<<<<<< HEAD
>>>>>>> 14264dae ([Mobile] home page domain layer)
=======
  String term;
  String tag;
  Params({required this.tag, required this.term});
>>>>>>> 3c40e5a6 ([Mobile] home page domain layer)
=======
>>>>>>> 45ce3b90f7597f464f062d467352d6466d59949b
>>>>>>> f340f282cc677cc910fd6b6f528cf33da32dd0c1
}
