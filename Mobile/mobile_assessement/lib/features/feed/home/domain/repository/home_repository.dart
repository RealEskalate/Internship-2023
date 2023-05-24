import 'package:mobile_assessement/core/error/failures.dart';
import 'package:mobile_assessement/features/feed/home/domain/entity/home.dart';
import 'package:dartz/dartz.dart';

abstract class HomeRepository {
  Future<Either<Failure, Home>> search(String city);
  // Future<Either<Failure, List<Home>>> getFav();
}
