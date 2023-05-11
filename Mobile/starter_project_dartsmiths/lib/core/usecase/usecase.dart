import 'package:dartz/dartz.dart';

import '../error/profile_failures.dart';

abstract class Usecase<Type, Params> {
  Future<Either<Failure, Type>> call(Params params);
}
