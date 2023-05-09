import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/core/usecases/usecase.dart';
import 'package:dark_knights/features/user_profile/domain/entities/user_entity.dart';
import 'package:dark_knights/features/user_profile/domain/repositories/user_repository.dart';
import 'package:dark_knights/features/user_profile/domain/usecases/get_user.dart';
import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

class GetNumberOfFollowing implements UseCase<int,Params> {
  final UserRepository repo;
 GetNumberOfFollowing(this.repo);
  
@override
  Future<Either<Failure,int >> call(Params params) async {
   return await repo.getNumberOfFollowing(params.id);
  }
}
  

