import 'package:dartsmiths/core/error/exceptions.dart';
import 'package:dartz/dartz.dart';

import 'package:dartsmiths/features/authentication/domain/entity/authentication_payload.dart';

import 'package:dartsmiths/core/error/failures.dart';

import '../../../../core/network/network_info.dart';
import '../../domain/repository/login_repository.dart';
import '../datasource/authentication_remote_datasource.dart';

class AuthenticationRepositoryImpl implements AuthenticationRepository {
  AuthenticationRemoteDataSource remotedataSource;
  NetworkInfo networkInfo;

  AuthenticationRepositoryImpl(
      {required this.remotedataSource, required this.networkInfo});

  @override
  Future<Either<Failure, UserAuthCredential>> login(
      {required String username, required String password}) async {
    
    if (await networkInfo.isConnected) {
      try {
        return Right(
            await remotedataSource.login(username, password));
      } on ServerException {
        return Left(ServerFailure());
      }
    } else {
      return Left(NetworkFailure());
    }
  }
}
