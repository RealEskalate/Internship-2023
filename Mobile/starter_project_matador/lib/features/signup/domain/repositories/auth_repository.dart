import 'package:dartz/dartz.dart';
import 'package:matador/core/error/failures.dart';
import 'package:matador/features/signup/domain/entities/user.dart';


abstract class AuthRepository {
  Future<Either<Failure, User>> signUp(String email, String password);
}
