import 'dart:async';

import 'package:dartz/dartz.dart';
import '../../../../core/errors/failures.dart';
import '../entities/Issue_entity.dart';

abstract class IssueRepository {
  Future<Either<Failure, List<Issue>>> getIssue();
  Future<Either<Failure, Issue>>getIssueById(String id);}
 
