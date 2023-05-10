import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/core/usecases/usecase.dart';
import 'package:dark_knights/features/user_profile/domain/entities/user_entity.dart';
import 'package:dark_knights/features/user_profile/domain/repositories/user_repository.dart';
import 'package:dark_knights/features/user_profile/domain/usecases/get_user.dart';
import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

class GetFollower implements UseCase<List<UserEntity>,String> {
  final UserRepository repo;
 GetFollower(this.repo);
  
@override
  Future<Either<Failure,List<UserEntity>>> call(String id) async {
   return await repo.getFollowers(id);
  }
}