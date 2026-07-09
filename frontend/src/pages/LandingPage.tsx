import { useQuery } from '@tanstack/react-query';
import { fetchHealthStatus } from '../services/healthApi';
import { Badge } from '@/components/ui/badge';
import { Loader2, CheckCircle, XCircle, RefreshCw } from 'lucide-react';
import type { HealthStatus } from '../types/api';

function LandingPage() {
  const {
    data,
    isLoading,
    isError,
    error,
    refetch,
  } = useQuery({
    queryKey: ['health'],
    queryFn: fetchHealthStatus,
    refetchOnWindowFocus: false,
    retry: 1,
  });

  const health: HealthStatus | null = data?.data ?? null;

  return (
    <div className="min-h-screen flex items-center justify-center bg-background p-4">
      <div className="w-full max-w-md">
        <div className="rounded-lg border bg-card text-card-foreground shadow-sm p-6 space-y-6">
          <div className="text-center space-y-2">
            <h1 className="text-2xl font-bold tracking-tight">
              Personal Productivity Platform
            </h1>
            <p className="text-sm text-muted-foreground">
              System health dashboard
            </p>
          </div>

          {/* Loading state */}
          {isLoading && (
            <div className="flex flex-col items-center gap-3 py-4">
              <Loader2 className="h-8 w-8 animate-spin text-muted-foreground" />
              <p className="text-sm text-muted-foreground">
                Checking platform status...
              </p>
            </div>
          )}

          {/* Error / unreachable state */}
          {isError && (
            <div className="flex flex-col items-center gap-3 py-4">
              <XCircle className="h-8 w-8 text-destructive" />
              <Badge variant="destructive">Offline</Badge>
              <p className="text-sm text-muted-foreground text-center">
                Unable to reach the platform API.
                {error instanceof Error && (
                  <span className="block text-xs mt-1">{error.message}</span>
                )}
              </p>
              <button
                onClick={() => refetch()}
                className="inline-flex items-center gap-2 rounded-md bg-primary px-4 py-2 text-sm font-medium text-primary-foreground hover:bg-primary/90 transition-colors"
              >
                <RefreshCw className="h-4 w-4" />
                Retry
              </button>
            </div>
          )}

          {/* Healthy state */}
          {health && (
            <div className="space-y-4 py-2">
              <div className="flex items-center justify-between">
                <span className="text-sm font-medium">API Status</span>
                <div className="flex items-center gap-2">
                  <CheckCircle className="h-4 w-4 text-green-500" />
                  <Badge className="bg-green-100 text-green-800 border-green-200 hover:bg-green-100">
                    {health.status}
                  </Badge>
                </div>
              </div>

              <div className="flex items-center justify-between">
                <span className="text-sm font-medium">Database</span>
                <div className="flex items-center gap-2">
                  {health.database === 'Connected' ? (
                    <CheckCircle className="h-4 w-4 text-green-500" />
                  ) : (
                    <XCircle className="h-4 w-4 text-destructive" />
                  )}
                  <Badge
                    variant={health.database === 'Connected' ? 'default' : 'destructive'}
                    className={
                      health.database === 'Connected'
                        ? 'bg-green-100 text-green-800 border-green-200 hover:bg-green-100'
                        : ''
                    }
                  >
                    {health.database}
                  </Badge>
                </div>
              </div>

              <div className="flex items-center justify-between">
                <span className="text-sm font-medium">Last Checked</span>
                <span className="text-sm text-muted-foreground">
                  {new Date(health.timestamp).toLocaleString()}
                </span>
              </div>
            </div>
          )}
        </div>
      </div>
    </div>
  );
}

export default LandingPage;
