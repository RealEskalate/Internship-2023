import 'package:dark_knights/features/article/domain/repositories/article_repository.dart';
import 'package:dartz/dartz.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import '../../../../core/errors/failures.dart';
import '../../../../core/usecases/usecase.dart';
import '../../domain/entities/article.dart';
import '../../domain/usecases/delete_article.dart';
import '../../domain/usecases/get_articles.dart';
import '../../domain/usecases/get_article_by_id.dart';
import '../../domain/usecases/post_article.dart';
import '../../domain/usecases/update_articles.dart';
import '../../domain/usecases/get_articles_by_user_id.dart';
import 'package:equatable/equatable.dart';
import '../../data/models/article_model.dart';

part 'article_event.dart';
part 'article_state.dart';

class ArticleBloc extends Bloc<ArticleEvent, ArticleState> {
  final DeleteArticle deleteArticle;
  final UpdateArticle updateArticle;
  final PostArticle postArticle;
  final GetArticleById getArticleById;
  final GetArticlesByUserId getArticleByUserId;
  final ArticleRepository repository;

  ArticleState articleSuccessOrFailure(Either<Failure, Article> data) {
    return data.fold(
      (failure) => ArticleFailureState(error: failure),
      (success) => ArticleSuccessState(article: success),
    );
  }

  ArticleState articlesSuccessOrFailure(Either<Failure, List<Article>> data) {
    return data.fold(
      (failure) => ArticleFailureState(error: failure),
      (success) => ArticlesSuccessState(articles: success),
    );
  }

  void _getArticleById(
      GetArticleByIdEvent event, Emitter<ArticleState> emit) async {
    emit(ArticleLoadingState());
    final result = await getArticleById(event.articleId);
    emit(articleSuccessOrFailure(result));
  }

  void _deleteArticle(
      DeleteArticleEvent event, Emitter<ArticleState> emit) async {
    emit(ArticleLoadingState());
    final result = await deleteArticle(event.articleId);
    emit(articleSuccessOrFailure(result));
  }

  void _updateArticle(
      UpdateArticleEvent event, Emitter<ArticleState> emit) async {
    emit(ArticleLoadingState());
    final result = await updateArticle(event.articleId, event.article);
    emit(articleSuccessOrFailure(result));
  }

  void _postArticle(PostArticleEvent event, Emitter<ArticleState> emit) async {
    emit(ArticleLoadingState());
    final result = await postArticle(event.article);
    emit(articleSuccessOrFailure(result));
  }

  void _getArticleByUserId(
      GetArticleByUserIdEvent event, Emitter<ArticleState> emit) async {
    emit(ArticleLoadingState());
    final result = await getArticleByUserId(event.userId);
    emit(articlesSuccessOrFailure(result));
  }

  ArticleBloc({
    required this.deleteArticle,
    required this.updateArticle,
    required this.postArticle,
    required this.getArticleById,
    required this.getArticleByUserId,
    required this.repository,
  }) : super(ArticleInitialState()) {
    on<GetArticleByIdEvent>(_getArticleById);
    on<GetArticleByUserIdEvent>(_getArticleByUserId);
    on<DeleteArticleEvent>(_deleteArticle);
    on<UpdateArticleEvent>(_updateArticle);
    on<PostArticleEvent>(_postArticle);
  }
}
