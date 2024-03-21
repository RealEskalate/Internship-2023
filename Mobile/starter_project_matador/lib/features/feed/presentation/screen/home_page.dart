import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:matador/core/utils/constants/colors.dart';
import 'package:matador/core/utils/constants/styles.dart';
import 'package:matador/core/utils/converters/convert_to_font_size.dart';
import 'package:matador/core/utils/converters/real_pixel_to_logical_pixel.dart';
import 'package:matador/features/feed/presentation/block/feed_bloc.dart';
import 'package:matador/features/feed/presentation/widgets/home_page_body.dart';
import 'package:matador/features/feed/presentation/widgets/menu_icon.dart';
import 'package:matador/features/feed/presentation/widgets/profile_avatar.dart';
import 'package:matador/injection/injection.dart';

class HomePage extends StatelessWidget {
  const HomePage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return BlocProvider<FeedBloc>(
        create: (_) => sl<FeedBloc>()..add(GetAllArticlesEvent()),
        child: Scaffold(
            backgroundColor: scaffoldBackGroundColor,
            appBar: AppBar(
              // To remove default elevation from AbbBarr
              bottomOpacity: 0.0,
              elevation: 0.0,
              scrolledUnderElevation: 0,
              toolbarHeight: convertPixelToScreenHeight(context, 45),
              backgroundColor: scaffoldBackGroundColor,

              leading: const MenuIcon(),
              title: Center(
                child: Text("Welcome Back!",
                    style: primaryTextStyle.copyWith(
                      fontSize: convertToFontSize(
                          height: convertPixelToScreenHeight(context, 40),
                          width: convertPixelToScreenWidth(context, 27)),
                    )),
              ),

              actions: const [
                ProfileAvatar(),
              ],
            ),
            body: BlocBuilder<FeedBloc, FeedState>(builder: (context, state) {
              if (state is LoadingFeedState) {
                return const Center(
                  child: CircularProgressIndicator(),
                );
              } else if (state is LoadedFeedState) {
                return HomePageBody(articles: state.articles);
              } else if (state is ErrorFeedState) {
                return Center(
                  child: Text(state.message),
                );
              } else {
                return Container();
              }
            })));
    // }
  }
}
