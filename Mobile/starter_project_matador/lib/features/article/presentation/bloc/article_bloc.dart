import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:matador/features/article/domain/entities/article.dart';
import 'package:matador/features/article/domain/usecases/get_article_by_id.dart';

import 'article_event.dart';
import 'article_state.dart';

class ArticleBloc extends Bloc<ArticleEvent, ArticleState> {
  final GetArticleById _getArticle;

  ArticleBloc({required GetArticleById getArticle})
      : _getArticle = getArticle,
        super(ArticleInitialState()) {
    on<GetArticleEvent>((event, emit) async {
      emit(ArticleLoadingState());

      final result = await _getArticle.call(event.articleId);

      result.fold(
        (failure) => emit(ArticleFailureState(error: failure.toString())),
        (article) => emit(ArticleSuccessState(article: article)),
      );
    });
  }
}