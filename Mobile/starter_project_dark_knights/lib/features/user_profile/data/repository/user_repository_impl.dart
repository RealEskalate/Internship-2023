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
  Future<Either<Failure, UserEntity>> createUser(UserEntity user) {
    // TODO: implement createUser
    throw UnimplementedError();
  }

  @override
  Future<Either<Failure, UserEntity>> deleteUser(String userId) {
    // TODO: implement deleteUser
    throw UnimplementedError();
  }

  @override
  Future<Either<Failure, UserEntity>> editUserProfile(UserEntity user) {
    // TODO: implement editUserProfile
    throw UnimplementedError();
  }

  @override
  Future<Either<Failure, List<UserEntity>>> getAllUsers() {
    // TODO: implement getAllUsers
    throw UnimplementedError();
  }

  @override
  Future<Either<Failure, List<UserEntity>>> getFollowers(String userId) {
    // TODO: implement getFollowers
    throw UnimplementedError();
  }

  @override
  Future<Either<Failure, List<UserEntity>>> getFollowing(String userId) {
    // TODO: implement getFollowing
    throw UnimplementedError();
  }

  @override
  Future<Either<Failure, int>> getNumberOfFollowers(String userId) {
    // TODO: implement getNumberOfFollowers
    throw UnimplementedError();
  }

  @override
  Future<Either<Failure, int>> getNumberOfFollowing(String userId) {
    // TODO: implement getNumberOfFollowing
    throw UnimplementedError();
  }

  @override
  Future<Either<Failure, UserEntity>> getUser(String userId) {
    // TODO: implement getUser
    throw UnimplementedError();
  }
}
