import 'package:dark_knights/features/Authentication/domain/entities/authentication_entitiy.dart';
import 'package:dartz/dartz.dart';
import '../../../../core/errors/failures.dart';

abstract class AuthenticationRepository {
  Future<Either<Failure, Authentication>> login(Authentication user);

  Future<Either<Failure, Authentication>> signup(Authentication newuser);
}
