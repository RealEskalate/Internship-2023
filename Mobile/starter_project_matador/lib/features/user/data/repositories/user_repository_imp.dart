import 'package:dartz/dartz.dart';
import 'package:matador/core/error/exceptions.dart';
import 'package:matador/core/error/failures.dart';
import 'package:matador/core/network/network_info.dart';
import 'package:matador/features/user/data/datasources/user_local_data_source.dart';
import 'package:matador/features/user/data/datasources/user_remote_data_source.dart';
import 'package:matador/features/user/domain/entities/user.dart';
import 'package:matador/features/user/domain/repositories/user_repository.dart';

class UserRepositoryImpl implements UserRepository {
  final UserRemoteDataSource remoteDataSource;
  final UserLocalDataSource localDataSource;
  final NetworkInfo networkInfo;

  UserRepositoryImpl(
      {required this.localDataSource, required this.remoteDataSource, required this.networkInfo});

  @override
  Future<Either<Failure, User>> addUser(User user) async {
    if (await networkInfo.isConnected) {
      try {
        final addedUser = await remoteDataSource.addUser(user);
        localDataSource.cacheUser(addedUser);
        return Right(addedUser);
      } on ServerException {
        return Left(ServerFailure());
      }
    } else {
      return Left(NetworkFailure());
    }
  }

  @override
  Future<Either<Failure, User>> getUserById(String id) async {
    if (await networkInfo.isConnected) {
      try {
        final remoteUser = await remoteDataSource.getUserById(id);
        localDataSource.cacheUser(remoteUser);
        return Right(remoteUser);
      } on ServerException {
        return Left(ServerFailure());
      }
    } else {
      try {
        final localUser = await localDataSource.getLastUser();
        return Right(localUser);
      } on CacheException {
        return Left(CacheFailure());
      }
    }
  }

  @override
  Future<Either<Failure, User>> editUserById(User user) async {
    if (await networkInfo.isConnected) {
      try {
        final updatedUser = await remoteDataSource.editUserById(user);
        localDataSource.cacheUser(updatedUser);
        return Right(updatedUser);
      } on ServerException {
        return Left(ServerFailure());
      }
    } else {
      return Left(NetworkFailure());
    }
  }

  @override
  Future<Either<Failure, void>> deleteUserById(String id) async {
    if (await networkInfo.isConnected) {
      try {
        remoteDataSource.deleteUserById(id);
        return const Right(null);
      } on ServerException {
        return Left(ServerFailure());
      }
    } else {
      return Left(NetworkFailure());
    }
  }

}