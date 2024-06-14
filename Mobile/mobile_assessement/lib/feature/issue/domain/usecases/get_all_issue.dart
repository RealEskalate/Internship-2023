import 'package:dartz/dartz.dart';
import 'package:flutter_application_1/core/errors/failures.dart';

import '../../../../core/utils/usecases/usecases.dart';
import '../entities/Issue_entity.dart';
import '../repositort/issue_repository.dart';

class GetAllIssue  {
  final IssueRepository repository;
  GetAllIssue(this.repository);

  Future<Either<Failure, List<Issue>>> call(NoParams params) async {
    return await repository.getIssue();
  }
}
