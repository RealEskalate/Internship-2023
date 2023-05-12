import 'package:dartz/dartz.dart';
import 'package:meta/meta.dart';

import 'package:matador/core/error/failures.dart';
import 'package:matador/core/error/exceptions.dart';
import 'package:matador/core/error/network/network_info.dart';

import 'package:matador/features/signup/domain/entities/user.dart';
import 'package:matador/features/signup/domain/repositories/auth_repository.dart';
import 'package:matador/features/signup/data/datasources/auth_local_data_source.dart';
import 'package:matador/features/signup/data/datasources/auth_remote_data_source.dart';

import '../models/user_model.dart';

class AuthRepositoryImpl implements AuthRepository {
  final AuthRemoteDataSource remoteDataSource;
  final AuthLocalDataSource localDataSource;
  final NetworkInfo networkInfo;

  AuthRepositoryImpl({
    required this.remoteDataSource,
    required this.localDataSource,
    required this.networkInfo,
  });

  @override
  Future<Either<Failure, User>> signUp(String email, String password) async {
    if (await networkInfo.isConnected) {
      try {
        final userModel = await remoteDataSource.signUp(email, password);
        localDataSource.cacheUser(userModel);
        return Right(userModel);
      } on ServerException {
        return Left(ServerFailure());
      }
    } else {
      return Left(NetworkFailure());
    }
  }
}
