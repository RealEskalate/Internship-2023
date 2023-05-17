import 'package:dark_knights/core/errors/exceptions.dart';
import 'package:dark_knights/core/network/network_info.dart';
import 'package:dark_knights/features/user_profile/data/datasources/user_local_data_source.dart';
import 'package:dark_knights/features/user_profile/data/datasources/user_remote_data_source.dart';
import 'package:dark_knights/features/user_profile/domain/entities/user_entity.dart';
import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/features/user_profile/domain/repositories/user_repository.dart';
import 'package:dartz/dartz.dart';

class UserRepositoryImpl implements UserRepository {
  final UserRemoteDataSource remoteDataSource;
  final UserLocalDataSource localDataSource;
  final NetworkInfo networkInfo;

  UserRepositoryImpl(
      {required this.remoteDataSource,
      required this.localDataSource,
      required this.networkInfo});

  @override
  Future<Either<Failure, UserEntity>> createUser(UserEntity user) async {
    try {
      final createdUser = await remoteDataSource.createUser(user);
      return Right(createdUser);
    } on ServerException {
      return Left(ServerFailure("Internal Server Error."));
    } on InputException {
      return Left(InputFailure("Input mismatch"));
    }
  }

  @override
  Future<Either<Failure, UserEntity>> deleteUser(String userId) async {
    try {
      final deletedUser = await remoteDataSource.deleteUser(userId);
      return Right(deletedUser);
    } on ServerException {
      return Left(ServerFailure("Internal Server Error."));
    }
  }

  @override
  Future<Either<Failure, UserEntity>> editUserProfile(UserEntity user) async {
    try {
      final editedUser = await remoteDataSource.editUserProfile(user);
      return Right(editedUser);
    } on ServerException {
      return Left(ServerFailure("Internal Server Error."));
    } on InputException {
      return Left(InputFailure("Input Mismatch"));
    }
  }

  @override
  Future<Either<Failure, List<UserEntity>>> getAllUsers() async {
    try {
      final users = await remoteDataSource.getAllUsers();
      return Right(users);
    } on ServerException {
      return Left(ServerFailure("Internal Server Error."));
    }
  }

  @override
  Future<Either<Failure, List<UserEntity>>> getFollowers(String userId) async {
    try {
      final followers = await remoteDataSource.getFollowers(userId);
      return Right(followers);
    } on ServerException {
      return Left(ServerFailure("Internal Server Error."));
    }
  }

  @override
  Future<Either<Failure, List<UserEntity>>> getFollowing(String userId) async {
    try {
      final following = await remoteDataSource.getFollowing(userId);
      return Right(following);
    } on ServerException {
      return Left(ServerFailure("Internal Server Error."));
    }
  }

  @override
  Future<Either<Failure, int>> getNumberOfFollowers(String userId) async {
    try {
      final noOfFollowers = await remoteDataSource.getNumberOfFollowers(userId);
      return Right(noOfFollowers);
    } on ServerException {
      return Left(ServerFailure("Internal Server Error."));
    }
  }

  @override
  Future<Either<Failure, int>> getNumberOfFollowing(String userId) async {
    try {
      final noOfFollowing = await remoteDataSource.getNumberOfFollowing(userId);
      return Right(noOfFollowing);
    } on ServerException {
      return Left(ServerFailure("Internal Server Error."));
    }
  }

  @override
  Future<Either<Failure, UserEntity>> getUser(String userId) async {
    try {
      final user = await remoteDataSource.getUser(userId);
      return Right(user);
    } on ServerException {
      return Left(ServerFailure("Internal Server Error."));
    }
  }
}
