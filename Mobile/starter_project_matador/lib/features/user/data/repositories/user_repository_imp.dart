import 'package:dartz/dartz.dart';
import 'package:matador/core/error/exceptions.dart';
import 'package:matador/core/error/failures.dart';
import 'package:matador/features/user/data/datasources/user_local_data_source.dart';
import 'package:matador/features/user/data/datasources/user_remote_data_source.dart';
import 'package:matador/features/user/data/models/user_model.dart';
import 'package:matador/features/user/domain/entities/user.dart';
import 'package:matador/features/user/domain/repositories/user_repository.dart';

class UserRepositoryImpl implements UserRepository {
  final UserRemoteDataSource remoteDataSource;
  final UserLocalDataSource localDataSource;

  UserRepositoryImpl({
    required this.localDataSource,
    required this.remoteDataSource,
  });

  @override
  Future<Either<Failure, User>> addUser(User user) async {
    try {
      final userToUserModel = user as UserModel;
      final addedUser = await remoteDataSource.addUser(userToUserModel);
      localDataSource.cacheUser(addedUser);
      return Right(addedUser);
    } on ServerException {
      return Left(ServerFailure());
    }
  }

  @override
  Future<Either<Failure, User>> getUserById(String id) async {
    try {
      final remoteUser = await remoteDataSource.getUserById(id);
      localDataSource.cacheUser(remoteUser);
      return Right(remoteUser);
    } on ServerException {
      return Left(ServerFailure());
    }
  }

  @override
  Future<Either<Failure, User>> editUserById(User user) async {
    try {
      final userToUserModel = user as UserModel;
      final updatedUser = await remoteDataSource.editUserById(userToUserModel);
      localDataSource.cacheUser(updatedUser);
      return Right(updatedUser);
    } on ServerException {
      return Left(ServerFailure());
    }
  }

  @override
  Future<Either<Failure, void>> deleteUserById(String id) async {
    try {
      remoteDataSource.deleteUserById(id);
      return const Right(null);
    } on ServerException {
      return Left(ServerFailure());
    }
  }
}
