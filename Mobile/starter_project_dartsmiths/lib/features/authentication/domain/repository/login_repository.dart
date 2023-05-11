import 'package:dartsmiths/core/errors/failures.dart';
import 'package:dartsmiths/features/authentication/domain/entity/authentication_payload.dart';
import 'package:dartz/dartz.dart';

abstract class AuthenticationRepository {
  Future<Either<Failure, UserAuthCredential>> login(
      {required String username, required String password});
}