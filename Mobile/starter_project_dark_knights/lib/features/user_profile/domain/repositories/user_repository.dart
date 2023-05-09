// ignore: depend_on_referenced_packages
import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/features/user_profile/domain/entities/user_entity.dart';
import 'package:dartz/dartz.dart';

abstract class UserRepository{

  Future<List<UserEntity> > getAllUsers();

  Future<Either<Failure,UserEntity>>  createUser(UserEntity user);

Future<Either<Failure,UserEntity>>  getFollowing(String userId);


 Future<Either<Failure,UserEntity>>  editUserProfile(UserEntity user);
 
 
Future<Either<Failure,UserEntity>>  getNumberOfFollowers(String userId);
  
Future<Either<Failure,UserEntity>>  deleteUser(String userId);

Future<Either<Failure,UserEntity>>  getUser(String userId);

 Future<Either<Failure,UserEntity>>  getNumberOfFollowing(String userId);
 
 Future<Either<Failure,UserEntity>>  getFollowers(String  userId);

}