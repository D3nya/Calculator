import Layout from "@/components/layout";
import { BrowserRouter, Routes, Route } from "react-router";
import { ExpressionPage } from "@/pages/expression/expression-page";
import { ROUTES } from "@/config/routes";
import { SumPage } from "@/pages/sum-page";
import { SubtractPage } from "@/pages/subtract-page";
import { MultiplyPage } from "@/pages/multiply-page";
import { DividePage } from "@/pages/divide-page";
import { PowPage } from "@/pages/pow-page";
import { SqrtPage } from "@/pages/sqrt-page";
import { HomePage } from "@/pages/home-page";
import { NotFoundPage } from "@/pages/not-found-page";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { ReactQueryDevtools } from "@tanstack/react-query-devtools";

function App() {
  const queryClient = new QueryClient();

  return (
    <QueryClientProvider client={queryClient}>
      <BrowserRouter>
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
