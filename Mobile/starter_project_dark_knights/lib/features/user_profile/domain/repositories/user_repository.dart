// ignore: depend_on_referenced_packages
import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/features/user_profile/domain/entities/user_entity.dart';
import 'package:dartz/dartz.dart';

abstract class UserRepository{

  Future<UserEntity>  getAllUsers();

  Future<UserEntity>  createUser(UserEntity user);
 
  Future<UserEntity>   editUserProfile(UserEntity user);
 
  Future<UserEntity>  getFollowing(String userId);

  Future<UserEntity>   getNumberOfFollowers(String userId);
  
  Future<UserEntity>   deleteUser(String userId);

  Future<UserEntity>   getUser(String userId);
  
  Future<UserEntity>   getNumberOfFollowing(String userId);
 
  Future<UserEntity>   getFollowers(String  userId);

}