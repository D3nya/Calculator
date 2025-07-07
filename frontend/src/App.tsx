import Layout from "@/components/layout";
import { BrowserRouter, Routes, Route } from "react-router";
import { ROUTES } from "@/config/routes";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { ReactQueryDevtools } from "@tanstack/react-query-devtools";
import { lazy } from "react";
import { AutoScrollToTop } from "@/components/auto-scroll-to-top";
const HomePage = lazy(() => import("@/pages/home/home-page"));
const ExpressionPage = lazy(() => import("@/pages/expression/expression-page"));
const SumPage = lazy(() => import("@/pages/sum-page"));
const SubtractPage = lazy(() => import("@/pages/subtract-page"));
const MultiplyPage = lazy(() => import("@/pages/multiply-page"));
const DividePage = lazy(() => import("@/pages/divide-page"));
const PowPage = lazy(() => import("@/pages/pow-page"));
const SqrtPage = lazy(() => import("@/pages/sqrt-page"));
const NotFoundPage = lazy(() => import("@/pages/not-found-page"));

function App() {
  const queryClient = new QueryClient();

  return (
    <QueryClientProvider client={queryClient}>
      <BrowserRouter>
        <AutoScrollToTop />
        <Routes>
          <Route element={<Layout />}>
            <Route path={ROUTES.appRoute} element={<HomePage />} />
            <Route path={ROUTES.expression.page} element={<ExpressionPage />} />
            <Route path={ROUTES.sum.page} element={<SumPage />} />
            <Route path={ROUTES.subtract.page} element={<SubtractPage />} />
            <Route path={ROUTES.multiply.page} element={<MultiplyPage />} />
            <Route path={ROUTES.divide.page} element={<DividePage />} />
            <Route path={ROUTES.pow.page} element={<PowPage />} />
            <Route path={ROUTES.sqrt.page} element={<SqrtPage />} />

            <Route path="*" element={<NotFoundPage />} />
          </Route>
        </Routes>
      </BrowserRouter>
      <ReactQueryDevtools initialIsOpen={false} />
    </QueryClientProvider>
  );
}

export default App;
