import 'package:dartsmiths/core/error/exceptions.dart';
import 'package:dartz/dartz.dart';

import 'package:dartsmiths/features/authentication/domain/entity/authentication_payload.dart';

import 'package:dartsmiths/core/error/failures.dart';

import '../../domain/repository/login_repository.dart';
import '../datasource/authentication_remote_datasource.dart';

class AuthenticationRepositoryImpl implements AuthenticationRepository {
  AuthenticationRemoteDataSource remotedataSource;

  AuthenticationRepositoryImpl(this.remotedataSource);

  @override
  Future<Either<Failure, UserAuthCredential>> login(
      {required String username, required String password}) async {
    try {
      return Right(remotedataSource.login(username, password) as UserAuthCredential);
    } on ServerException {
      return Left(ServerFailure());
    }
  }
}
