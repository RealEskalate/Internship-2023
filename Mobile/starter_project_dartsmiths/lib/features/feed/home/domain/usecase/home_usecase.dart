import 'package:dartsmiths/core/error/failures.dart';
import 'package:dartsmiths/core/usecases/usecase.dart';
import 'package:dartsmiths/features/feed/home/domain/repository/home_repository.dart';
import 'package:dartz/dartz.dart';
import '../entity/home.dart';

class Search extends UseCase<List<Home>, Params> {
  final HomeRepository homeRepository;

  Search({required this.homeRepository});
  @override
  Future<Either<Failure, List<Home>>> call(Params params) async {
    return await homeRepository.search(params.term!, params.tag!);
  }
}
class Params {
  String? term;
  String? tag;
  Params({this.tag, this.term});
}