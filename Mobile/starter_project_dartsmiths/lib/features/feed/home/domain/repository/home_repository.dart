import 'package:dartsmiths/core/error/failures.dart';
import 'package:dartsmiths/features/feed/home/domain/entity/home.dart';
import 'package:dartz/dartz.dart';

abstract class HomeRepository {
  Future<Either<Failure, Home>> search(String term, String tag);
  Future<Either<Failure, Home>> filterByTag(String tag);
}