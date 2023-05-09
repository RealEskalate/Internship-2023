import 'package:dark_knights/core/errors/failures.dart';
import 'package:dark_knights/core/usecases/usecase.dart';
import 'package:dark_knights/features/user_profile/domain/entities/user_entity.dart';
import 'package:dark_knights/features/user_profile/domain/repositories/user_repository.dart';
import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';

class GetUser implements UseCase<UserEntity,Params> {
  final UserRepository repo;
  GetUser(this.repo);
  
@override
  Future<Either<Failure, UserEntity>> call(Params params) async {
   return await repo.getUser(params.id);
  }
}
  

class Params extends Equatable {
  final String id;

  Params({required this.id});

  @override
  List<Object> get props => [id];
}