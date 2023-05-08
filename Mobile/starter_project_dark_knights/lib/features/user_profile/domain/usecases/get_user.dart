import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/features/user_profile/domain/entities/user_entity.dart';
import 'package:dark_knights/features/user_profile/domain/repositories/user_repository.dart';
import 'package:dartz/dartz.dart';

class GetUser {
  final UserRepository repo;
  GetUser(this.repo);
  
Future<UserEntity> getUser({
    required String userId
  }) async {
    return await repo.getUser(userId);
  }
}